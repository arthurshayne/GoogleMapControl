using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Collections;
using System.Text;
using Wrox.ProCSharp.Collections;
using AutoMapper;

namespace WebApplication1
{

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string strCon="Data Source=NLTDC01\\SQLServer2008;Initial Catalog=Percussion;Persist Security Info=True;User ID=pii;Password=4pii2c";//Sql Server连接字串

            //DataContext dc = new DataContext(strCon);
            //dc.Log = Response.Output;

            //PriorityDocumentManager pdm = new PriorityDocumentManager();
            //pdm.AddDocument(new Document("one", "Sample", 8));
            //pdm.AddDocument(new Document("two", "Sample", 3));
            //pdm.AddDocument(new Document("three", "Sample", 4));
            //pdm.AddDocument(new Document("four", "Sample", 8));
            //pdm.AddDocument(new Document("five", "Sample", 1));
            //pdm.AddDocument(new Document("six", "Sample", 9));
            //pdm.AddDocument(new Document("seven", "Sample", 1));
            //pdm.AddDocument(new Document("eight", "Sample", 1));

            //pdm.DisplayAllNodes();
            var map = Mapper.CreateMap<BookDto, Author>();
            map.ForMember(d => d.Name, opt => opt.MapFrom(s => s.FirstAuthorName))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.FirstAuthorDescription))
                .ForMember(d => d.ContactInfo,
                           opt => opt.ResolveUsing<FirstAuthorContactInfoResolver>());

            BookDto bkdto = new BookDto()
            {
                FirstAuthorName = "FirstAuthorName",
                FirstAuthorDescription = "FirstAuthorDescription",
                FirstAuthorBlog = "FirstAuthorBlog",
                FirstAuthorEmail = "FirstAuthorEmail",
                FirstAuthorTwitter = "FirstAuthorTwitter"
            };

            var au = Mapper.Map<BookDto, Author>(bkdto);


        }

        public class FirstAuthorContactInfoResolver : ValueResolver<BookDto, ContactInfo>
        {
            protected override ContactInfo ResolveCore(BookDto source)
            {
                var map = Mapper.CreateMap<BookDto, ContactInfo>();
                map.ConstructUsing(s => new ContactInfo() 
                {
                    Blog = s.FirstAuthorBlog,
                    Email = s.FirstAuthorEmail,
                    Twitter = s.FirstAuthorTwitter
                });

                return Mapper.Map<BookDto, ContactInfo>(source);
            }
        }


        public class BookStore
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }
            public Address Address { get; set; }
        }

        public class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string PostCode { get; set; }
        }

        public class Book
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Language { get; set; }
            public decimal Price { get; set; }
            public List<Author> Authors { get; set; }
            public DateTime? PublishDate { get; set; }
            public Publisher Publisher { get; set; }
            public int? Paperback { get; set; }
        }

        public class Publisher
        {
            public string Name { get; set; }
        }

        public class Author
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public ContactInfo ContactInfo { get; set; }
        }

        public class ContactInfo
        {
            public string Email { get; set; }
            public string Blog { get; set; }
            public string Twitter { get; set; }
        }

        public class BookStoreDto
        {
            public string Name { get; set; }
            public List<BookDto> Books { get; set; }
            public AddressDto Address { get; set; }
        }

        public class AddressDto
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string PostCode { get; set; }
        }

        public class BookDto
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Language { get; set; }
            public decimal Price { get; set; }
            public DateTime? PublishDate { get; set; }
            public string Publisher { get; set; }
            public int? Paperback { get; set; }
            public string FirstAuthorName { get; set; }
            public string FirstAuthorDescription { get; set; }
            public string FirstAuthorEmail { get; set; }
            public string FirstAuthorBlog { get; set; }
            public string FirstAuthorTwitter { get; set; }
            public string SecondAuthorName { get; set; }
            public string SecondAuthorDescription { get; set; }
            public string SecondAuthorEmail { get; set; }
            public string SecondAuthorBlog { get; set; }
            public string SecondAuthorTwitter { get; set; }
        }


    }


}
