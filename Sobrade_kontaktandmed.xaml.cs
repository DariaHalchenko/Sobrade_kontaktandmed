using System.Text.RegularExpressions;

namespace Sobrade_kontaktandmed;

public partial class Sobrade_kontaktandmed : ContentPage
{
    TableView tableview;
    SwitchCell sc;
    ImageCell ic;
    TableSection fotosection;
    Button btn_sms, btn_email, btn_helistada, btn_puhkus_rnd, btn_pildista, btn_valifoto;
    EntryCell ec_nimi, ec_email, ec_telefon, ec_kirjeldus;
    

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

        btn_valifoto = new Button
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
        btn_valifoto.Clicked += Btn_valifoto_Clicked;

        btn_pildista = new Button
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
            Text = "Saatke puhkusetervitused",
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
                new TableSection("Helistada")
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
                new TableSection("SMS ja Puhkus")
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
        Content = tableview;
    }

    // Метод для отправки случайного поздравления
    private async void Btn_puhkus_rnd_Clicked(object? sender, EventArgs e)
    {
        // Создание списка изображений
        List<string> foto = new List<string>
        {
            "pilt2.jpg",
            "pilt3.jpg",
            "pilt4.jpg",
            "pilt5.jpg",
            "pilt6.jpg"
        };

        // Выбираем случайное поздравление и изображение
        Random rnd = new Random();
        string rndPuhkus = puhkus[rnd.Next(puhkus.Count)];
        string selectedImage = foto[rnd.Next(foto.Count)];

        // Получаем контактные данные
        string telefon = ec_telefon.Text;
        string email = ec_email.Text;

        // Формируем полный путь к файлу
        string filePath = Path.Combine(FileSystem.CacheDirectory, selectedImage);

        // Проверяем, существует ли изображение в локальном хранилище
        if (!File.Exists(filePath))
        {
            await DisplayAlert("Viga", "Pildi ei leitud", "OK");
            return;
        }

        if (!string.IsNullOrWhiteSpace(telefon))
        {
            // Отправка через SMS
            await Sms.ComposeAsync(new SmsMessage(rndPuhkus, telefon));
        }
        else if (!string.IsNullOrWhiteSpace(email))
        {
            // Отправка через Email с вложением
            var emailMessage = new EmailMessage
            {
                Subject = "Pühadetervitus",
                Body = rndPuhkus,
                To = new List<string> { email }
            };

            // Добавление изображения как вложения
            var attachment = new EmailAttachment(filePath);
            emailMessage.Attachments.Add(attachment);

            await Email.ComposeAsync(emailMessage);
        }
        else
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
            // Создаем правильный URI для звонка
            Uri telefonUri = new Uri($"tel:{telefon}");
            
            // Открываем приложение для звонков
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
        EmailMessage e_mail = new EmailMessage
        {
            Subject = text,
            Body = kirjeldus,
            BodyFormat = EmailBodyFormat.PlainText,
            To = new List<string>(new[] { ec_email.Text })
        };
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
        await SavePhoto(foto);
    }

    private async void Btn_pildista_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult foto = await MediaPicker.Default.CapturePhotoAsync();
            await SavePhoto(foto);
        }
        else
        {
            await Shell.Current.DisplayAlert("OOPS", "Your device isn’t supported", "Ok");
        }
    }

    // Метод для сохранения фото в локальное хранилище
    private async Task SavePhoto(FileResult foto)
    {
        if (foto != null)
        {
            string localFilePath = Path.Combine(FileSystem.CacheDirectory, foto.FileName);
            using Stream sourceStream = await foto.OpenReadAsync();
            using FileStream localFileStream = File.OpenWrite(localFilePath);
            await sourceStream.CopyToAsync(localFileStream);
            await Shell.Current.DisplayAlert("Success", "Photo saved successfully", "Ok");
        }
    }
}
