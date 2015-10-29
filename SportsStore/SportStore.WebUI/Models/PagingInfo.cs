using System;

namespace SportStore.WebUI.Models
{
    //View model
    public class PagingInfo
    {
        public int TotalItem { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages 
        {
            get 
            {
                return (int)Math.Ceiling((decimal)TotalItem / ItemsPerPage);
                } 
        }
    }
}