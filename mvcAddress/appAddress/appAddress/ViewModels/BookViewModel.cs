
namespace appAddress.ViewModels
{
    using appAddress.Models;
    using appAddress.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class BookViewModel:BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Book> books;
        #endregion

        #region Properties
        public ObservableCollection<Book> Books
        {
            get { return this.books; }
            set { SetValue(ref this.books, value); }
        }
        #endregion

        #region Constructor
        public BookViewModel()
        {
            this.apiService = new ApiService();
            this.LoadBooks();
        }
        #endregion

        #region Method
        private async void LoadBooks()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Internet Error", 
                    connection.Message,
                    "Accept"
                    );
                return;
            }
            var response = await apiService.GetList<Book>(
                "http://localhost:49864/",
                "api/",
                "Books"
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Service Book Error",
                    response.Message,
                    "Accept"
                    );
                return;
            }

            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ListBook = (List<Book>)response.Result;

            this.Books = new ObservableCollection<Book>(this.ToBookCollect());
        }

        private IEnumerable<Book> ToBookCollect()
        {
            ObservableCollection<Book> collect = new ObservableCollection<Book>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach(var lista in main.ListBook)
            {
                Book book = new Book();
                book.BookID = lista.BookID;
                book.name = lista.name;
                book.type = lista.type;
                book.contact = lista.contact;
                collect.Add(book);
            }
            return (collect);
        }
        #endregion
    }
}