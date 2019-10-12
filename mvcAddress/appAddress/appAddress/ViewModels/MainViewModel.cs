using appAddress.Models;
using System.Collections.Generic;

namespace appAddress.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<Book> ListBook { get; set; }
        #endregion 

        #region ViewModel
        public BookViewModel bookViewModel { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.bookViewModel = new BookViewModel();
        } 
        #endregion

        #region singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if(instance==null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion
    }
}
