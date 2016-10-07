using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

namespace ListViewSeparatorLinesExample
{
    public partial class ListViewSeparatorLinesExamplePage : ContentPage
    {
        public ListViewSeparatorLinesExamplePage()
        {
            InitializeComponent();
            FillListView();
        }

        public void FillListView()
        {
            var listOfRandom = new List<Random>();
            //for (int i = 0; i < 2; i++)
            //{
            //    listOfRandom.Add(new Random
            //    {
            //        Name = System.IO.Path.GetRandomFileName(),
            //        Detail = System.IO.Path.GetRandomFileName()
            //    });
            //}
            listOfRandom.Add(new Random {Name = "Rodrigo Amaro", Detail="Pessoa Física" });
            listOfRandom.Add(new Random { Name = "Rodrigo Ambrósio", Detail = "Pessoa Física" });

            listOfRandom.Add(new Random { Name = "Juliana Pinto", Detail = "Pessoa Física" });
            listOfRandom.Add(new Random { Name = "Juliana Santos", Detail = "Pessoa Jurídica" });

            var grouped = from r in listOfRandom
                          orderby r.Name
                          group r by r.NameSort into randomGrouped
                          select new Grouping<string, Random>(randomGrouped.Key, randomGrouped);

            var source = new ObservableCollection<Grouping<string,Random>>(grouped);
            lvRandom.ItemsSource = source;
        }
    }

    public class Random
    {
        public string Name { get; set; }
        public string Detail { get; set; }

        public string NameSort => Name[0].ToString();
    }

    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                Items.Add(item);
        }
    }
}
