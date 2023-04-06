using AIClient.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace AIClient.ViewModels
{
    public class HistoryBoardViewModel : BaseViewModel
    {
        public ObservableRangeCollection<historyRequest> History_Prompt { get; set; }
        public ObservableRangeCollection<Grouping<string, historyRequest>> requestGroup { get; set; } // By type

        historyRequest historyRequestSelected;
        public historyRequest SelectedHistoryRequestCard
        {
            get => historyRequestSelected;
            set => SetProperty(ref historyRequestSelected, value);
        }

        async Task Selected(historyRequest select)
        {
            if (select == null)
                return;
            historyRequestSelected = null;
            await Application.Current.MainPage.DisplayAlert("Selected", select.contentRequest, "Okay");
        }


        public HistoryBoardViewModel()
        {
            History_Prompt = new ObservableRangeCollection<historyRequest>();
            requestGroup = new ObservableRangeCollection<Grouping<string, historyRequest>>();

            LoadMore();
            LoadMoreCommand = new Command(LoadMore);
            RefreshCommand = new AsyncCommand(Refresh);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
            SelectedCommand = new AsyncCommand<historyRequest>(Selected);


        }
        public Command LoadMoreCommand { get; }
        public AsyncCommand RefreshCommand { get; }
        public Command ClearCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public AsyncCommand<historyRequest> SelectedCommand { get; }
        public

        void DelayLoadMore()
        {
            if (History_Prompt.Count <= 10)
                return;

            LoadMore();
        }


        void Clear()
        {
            History_Prompt.Clear();
            requestGroup.Clear();
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            History_Prompt.Clear();

            IsBusy = false;
        }

        void LoadMore()
        {
            if (History_Prompt.Count >= 20)
                return;

            var image = "coffeebag.png";
            History_Prompt.Add(new historyRequest { contentRequest = "Draw a cofffe 1bag please", respondFromServer = image, typeRequest = "Text_To_Image", timeOccured = "Today", Image_Res = image });
            History_Prompt.Add(new historyRequest { contentRequest = "Draw a cofffe 2bag please", respondFromServer = image, typeRequest = "Text_To_Image", timeOccured = "Today", Image_Res = image });
            History_Prompt.Add(new historyRequest { contentRequest = "How the Weather Today", respondFromServer = "The weather today is 25F outside", typeRequest = "Text_To_Text", timeOccured = "Today", Image_Res = image });
            History_Prompt.Add(new historyRequest { contentRequest = "Draw a cofffe bag please", respondFromServer = image, typeRequest = "Text_To_Image", timeOccured = "Today", Image_Res = image });
            History_Prompt.Add(new historyRequest { contentRequest = "How the Weather Today", respondFromServer = "The weather today is 25F outside", typeRequest = "Text_To_Text", timeOccured = "Today", Image_Res = image });
            History_Prompt.Add(new historyRequest { contentRequest = "How the Weather Today", respondFromServer = "The weather today is 25F outside", typeRequest = "Text_To_Text", timeOccured = "Today", Image_Res = image });
            History_Prompt.Add(new historyRequest { contentRequest = image, respondFromServer = "A bag of Coffee", typeRequest = "Image_To_Text", timeOccured = "Today", Image_Res = image });

            requestGroup.Clear();

            requestGroup.Add(new Grouping<string, historyRequest>("Text_To_Text", new[] { History_Prompt[2] }));
            requestGroup.Add(new Grouping<string, historyRequest>("Text_To_Image", History_Prompt.Take(2)));
        }
    }
}
