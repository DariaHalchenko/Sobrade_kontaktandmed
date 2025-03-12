using System.Text.RegularExpressions;

namespace Sobrade_kontaktandmed;

public partial class Sobrade_kontaktandmed : ContentPage
{
    private string lisafoto; 
    TableView tableview;
    SwitchCell sc;
    ImageCell ic;
    TableSection fotosection;
    Button btn_sms, btn_email, btn_helistada, btn_puhkus_rnd, btn_pildista, btn_valifoto;
    EntryCell ec_nimi, ec_email, ec_telefon, ec_kirjeldus;
    Picker picker;
    string varv;
    

    List<string> puhkus = new List<string>
    {
        "Palju õnne uue aasta puhul! Soovin, et iga minut tooks ainult rõõmu, iga sündmus oleks meeldiv ja kauaoodatud ning iga mõte lõppeks eduka tulemusega!",
        "Head sõbrapäeva! Head sõbrapäeva Lase rutiin unustada. Lase oma südamel tantsida. Ja veebruar on kuum!",
        "Lase kevadel oma südames ärgata. Avaneks uks õnne juurde. Sooja, emotsioone, helgeid emotsioone. Head 8. märtsi!",
        "Tulgu arm sinu koju ja võtku su mured ja kurbused kaasa! Ela, armasta ja hinda iga hetke ja päeva!",
        "Häid lihavõtteid! Kristus on üles tõusnud! Õnnistusi taevast. Olgu teie kodus headus, õnne, rõõmu ja soojust."
    };
    public Sobrade_kontaktandmed()
    {
        // Поля ввода
        ec_nimi = new EntryCell
        {
            Label = "Nimi:",
            Placeholder = "Sisesta oma sõbra nimi"
        };
        ec_email = new EntryCell
        {
            Label = "Email:",
            Placeholder = "Sisesta email",
            Keyboard = Keyboard.Email
        };
        ec_telefon = new EntryCell
        {
            Label = "Telefon:",
            Placeholder = "Sisesta tel.number",
            Keyboard = Keyboard.Telephone
        };
        ec_kirjeldus = new EntryCell
        {
            Label = "Kirjeldus:",
            Placeholder = "Sisesta Kirjeldus",
            Keyboard = Keyboard.Text
        };

        picker = new Picker
        {
            Title = "Värvide valik",
            ItemsSource = new List<string> { "Punane", "Sinine", "Roheline", "Kollane",
            "Oranz", "Roosa", "Pruun", "Lilla", "Valge" },
            SelectedIndex = 0
        };
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

        btn_valifoto = new Button
        {
            Text = "Valige foto",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_valifoto.Clicked += Btn_valifoto_Clicked;

        btn_pildista = new Button
        {
            Text = "Tee foto",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_pildista.Clicked += Btn_pildista_Clicked;

        btn_sms = new Button
        {
            Text = "SMS-i saatmine",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_sms.Clicked += Btn_sms_Clicked;

        btn_email = new Button
        {
            Text = "Saada e-kiri",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_email.Clicked += Btn_email_Clicked;

        btn_helistada = new Button
        {
            Text = "Helista",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_helistada.Clicked += Btn_helistada_Clicked;

        btn_puhkus_rnd = new Button
        {
            Text = "Rnd puhkus",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_puhkus_rnd.Clicked += Btn_puhkus_rnd_Clicked;

        sc = new SwitchCell { Text = "Näita veel" };
        sc.OnChanged += Sc_OnChanged;
        ic = new ImageCell
        {
            ImageSource = ImageSource.FromFile("pilt.jpg"),
            Text = "Foto nimetus",
            Detail = "Foto kirjeldus"
        };
        fotosection = new TableSection();
        tableview = new TableView
        {
            Intent = TableIntent.Form, // могут быть Menu, Data, Settings
            Root = new TableRoot("Andmete sisestamine")
            {
                new TableSection("Põhiandmed:")
                {
                    ec_nimi
                },
                new TableSection("Kontaktandmed:")
                {
                    ec_telefon,
                    ec_email,
                    sc
                },
                new TableSection("Kirjeldus:")
                {
                    ec_kirjeldus
                },
                fotosection,
                new TableSection("Helistada ja SMS")
                {
                    new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.Center,
                            Children = { btn_helistada, btn_sms }
                        }
                    }
                },
                new TableSection("E-mail ja Puhkus")
                {
                    new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.Center,
                            Children = { btn_email, btn_puhkus_rnd }
                        }
                    }
                },
                new TableSection("FOTO")
                {
                    new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.Center,
                            Children = {  btn_valifoto, btn_pildista }
                        }
                    }
                }
            }
        };
        StackLayout st = new StackLayout
        {
            Children =
            {
                picker,  
                tableview  
            }
        };
        Content = st;
    }

    // Метод для отправки случайного поздравления
    private async void Btn_puhkus_rnd_Clicked(object? sender, EventArgs e)
    {
        Random rnd = new Random();
        string rnd_puhkus = puhkus[rnd.Next(puhkus.Count)];

        string telefon = ec_telefon.Text;
        string email = ec_email.Text;

        string tegevust = await DisplayActionSheet("Valige saatmisviis", "Tühista", null, "SMS", "E-mail");

        if (tegevust == "SMS" && !string.IsNullOrWhiteSpace(telefon))
        {
            await Sms.ComposeAsync(new SmsMessage(rnd_puhkus, telefon));
        }
        else if (tegevust == "E-mail" && !string.IsNullOrWhiteSpace(email))
        {
            var e_mail = new EmailMessage
            {
                Subject = "Pühadetervitus",
                Body = rnd_puhkus,
                To = new List<string> { email }
            };

            await Email.ComposeAsync(e_mail);
        }
        else if (tegevust != "Tühista")
        {
            await DisplayAlert("Viga", "Kontaktandmed puuduvad", "OK");
        }
    }


    // Метод для звонка
    private async void Btn_helistada_Clicked(object? sender, EventArgs e)
    {
        string telefon = ec_telefon.Text;
        if (!string.IsNullOrWhiteSpace(telefon))
        {
            Uri telefonUri = new Uri($"tel:{telefon}");

            await Launcher.OpenAsync(telefonUri);
        }
        else
        {
            await DisplayAlert("Viga", "Telefoninumber puudub", "OK");
        }
    }


    // Метод для отправки Email
    private async void Btn_email_Clicked(object? sender, EventArgs e)
    {
        string kirjeldus = ec_kirjeldus.Text;
        string nimi = ec_nimi.Text;  
        string text = $"Tere, {nimi}";
        
        var e_mail = new EmailMessage
        {
            Subject = text,
            Body = kirjeldus,
            BodyFormat = EmailBodyFormat.PlainText,
            To = new List<string>(new[] { ec_email.Text })
        };

        if (!string.IsNullOrEmpty(lisafoto))
        {
            e_mail.Attachments.Add(new EmailAttachment(lisafoto));
        }
        if (Email.Default.IsComposeSupported)
        {
            await Email.Default.ComposeAsync(e_mail);
        }
    }

    // Метод для отправки SMS
    private async void Btn_sms_Clicked(object? sender, EventArgs e)
    {
        string telefon = ec_telefon.Text;
        string kirjeldus = ec_kirjeldus.Text;
        SmsMessage sms = new SmsMessage(kirjeldus, telefon);
        if (telefon != null && Sms.Default.IsComposeSupported)
        {
            await Sms.Default.ComposeAsync(sms);
        } 
    }

    private void Sc_OnChanged(object? sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            fotosection.Title = "Foto:";
            fotosection.Add(ic);
            sc.Text = "Peida";
        }
        else
        {
            fotosection.Title = "";
            fotosection.Remove(ic);
            sc.Text = "Näita veel";
        }
    }
    private async void Btn_valifoto_Clicked(object sender, EventArgs e)
    {
        FileResult foto = await MediaPicker.Default.PickPhotoAsync();
        await SalvestaFoto(foto);
    }

    private async void Btn_pildista_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult foto = await MediaPicker.Default.CapturePhotoAsync();
            await SalvestaFoto(foto);
        }
        else
        {
            await Shell.Current.DisplayAlert("Viga", "Teie seade ei ole toetatud", "Ok");
        }
    }

    // Метод для сохранения фото в локальное хранилище
    private async Task SalvestaFoto(FileResult foto)
    {
        if (foto != null)
        {
            // Сохраняем путь к файлу в переменную photoPath
            lisafoto = Path.Combine(FileSystem.CacheDirectory, foto.FileName);
            
            using Stream sourceStream = await foto.OpenReadAsync();
            using FileStream localFileStream = File.OpenWrite(lisafoto);
            await sourceStream.CopyToAsync(localFileStream);

            ic.ImageSource = ImageSource.FromFile(lisafoto);

            await Shell.Current.DisplayAlert("Edu", "Foto on edukalt salvestatud", "Ok");
        }
    }
    private void Picker_SelectedIndexChanged(object? sender, EventArgs e)
    {
        int index = picker.SelectedIndex; 

        // Массив цветов для выбора
        List<Color> varv = new List<Color>
        {
            Color.FromArgb("#fe646f"),  
            Color.FromArgb("#87CEFA"),  
            Color.FromArgb("#90EE90"),  
            Color.FromArgb("#F0E68C"),  
            Color.FromArgb("#FFA07A"),  
            Color.FromArgb("#FFB6C1"),  
            Color.FromArgb("#CD853F"),  
            Color.FromArgb("#EE82EE"),  
            Color.FromArgb("#FFFFFF")   
        };

        if (index >= 0 && index < varv.Count)
        {
            Color color = varv[index]; 

            if (tableview != null)
            {
                tableview.BackgroundColor = color;
            }
        }
    }
}
