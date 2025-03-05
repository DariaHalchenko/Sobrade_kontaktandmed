namespace Sobrade_kontaktandmed;

public partial class Table_Page : ContentPage
{
    TableView tableview;
    SwitchCell sc;
    ImageCell ic;
    TableSection fotosection;
    public Table_Page()
    {
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
                    new EntryCell
                    {
                        Label="Nimi: ",
                        Placeholder="Sisesta oma sõbra nimi",
                        Keyboard=Keyboard.Default
                    }
                },
                new TableSection("Kontaktandmed:")
                {
                    new EntryCell
                    {
                        Label="Telefon",
                        Placeholder="Sisesta tel.number",
                        Keyboard=Keyboard.Telephone
                    },
                    new EntryCell
                    {
                        Label="Email",
                        Placeholder="Sisesta email",
                        Keyboard=Keyboard.Email
                    },
                    sc
                },
                fotosection
            }
        };
        Content = tableview;
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
}