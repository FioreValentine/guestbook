using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//будет работать с записями через Entity
namespace Guestbook.Models
{
    public class GuestbookContext: DbContext
    {
        public GuestbookContext(): base("Guestbook") { } //определяем название базы
        public DbSet<GuestbookEntry> Entries { get; set; } //к данным таблицы будем стучаться здесь
    }
}