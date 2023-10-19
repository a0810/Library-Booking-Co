using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Booking_Co.BookManagement
{
    class xmlController
    {
        string path = "BookInventory.xml";
        public void addBook(Book newBook)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode ROOT = doc.SelectSingleNode("/inventory");
            XmlNode Book = doc.CreateElement("book");
            XmlNode Title = doc.CreateElement("title");
            XmlNode Genre = doc.CreateElement("genre");
            XmlNode Author = doc.CreateElement("author");
            XmlNode Price = doc.CreateElement("price");
            XmlNode PublishDate = doc.CreateElement("publishDate");
            XmlNode Description = doc.CreateElement("description");
            XmlNode ISBN = doc.CreateElement("ISBN");
            XmlNode ID = doc.CreateElement("ID");
            XmlNode Publisher = doc.CreateElement("publisher");
            XmlNode Available = doc.CreateElement("available");
            XmlNode Counter = doc.CreateElement("counter");

            Title.InnerText = newBook.title;
            Genre.InnerText = newBook.genre;
            Author.InnerText = newBook.author;
            Price.InnerText = newBook.price.ToString();
            PublishDate.InnerText = newBook.publishDate.ToString();
            Description.InnerText = newBook.description;
            ISBN.InnerText = newBook.ISBN.ToString();
            ID.InnerText = newBook.ID;
            Publisher.InnerText = newBook.publisher;
            Available.InnerText = newBook.available;
            Counter.InnerText = newBook.counter.ToString();

            Book.AppendChild(Author);
            Book.AppendChild(Title);
            Book.AppendChild(Genre);
            Book.AppendChild(Publisher);
            Book.AppendChild(PublishDate);
            Book.AppendChild(Description);
            Book.AppendChild(Price);
            Book.AppendChild(ISBN);
            Book.AppendChild(ID);
            Book.AppendChild(Available);
            Book.AppendChild(Counter);

            ROOT.AppendChild(Book);
            doc.Save(path);
        }
        public void deleteBook(string ID, Book delBooks)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//book[ID='" + ID + "']");
            nodes.ParentNode.RemoveChild(nodes);
            doc.Save(path);
        }

        public void updateBook(string ID, Book updateBook)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldBook = doc.SelectSingleNode("//book[ID='" + ID + "']");
            oldBook.ChildNodes.Item(0).InnerText = updateBook.author;
            oldBook.ChildNodes.Item(1).InnerText = updateBook.title;
            oldBook.ChildNodes.Item(2).InnerText = updateBook.genre;
            oldBook.ChildNodes.Item(3).InnerText = updateBook.publisher;
            oldBook.ChildNodes.Item(4).InnerText = updateBook.publishDate.ToString();
            oldBook.ChildNodes.Item(5).InnerText = updateBook.description;
            oldBook.ChildNodes.Item(6).InnerText = updateBook.price.ToString();
            oldBook.ChildNodes.Item(7).InnerText = updateBook.ISBN.ToString();
            //oldBook.ChildNodes.Item(7).InnerText = updateBook.available;
            doc.Save(path);

        }

    }
}
