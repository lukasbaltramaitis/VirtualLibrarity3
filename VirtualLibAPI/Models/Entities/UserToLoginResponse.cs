using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualLibrarity.Models
{
    public struct UserToLoginResponse
    {
        public User UserInfo { get; set; }
        public Book[] BorrowedBooks { get; set; }
        public string Exception { get; set; }
    }
}