﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AIClient.ViewModels
{
    public class RequestPageViewModel
    {
        public RequestPageViewModel()
        {
            MenuList = GetMenu();
        }
        public List<Pick> MenuList { get; set; }

        private List<Pick> GetMenu()
        {
            return new List<Pick>
            {
                new Pick { Title = "Text To Text", Image = "IMG05.png", Description = "Request the question and we will answer it for you", Price = "$0.99" },
                new Pick { Title = "Text To Image", Image = "IMG04.png", Description = "Describe an Image and we will draw it for you", Price = "$0.99" },
                new Pick { Title = "Image To Text", Image = "IMG01.png", Description = "Input an Image and we will describe it for you", Price = "$1.25" }
            };
        }
    }
}
