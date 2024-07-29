using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Notifications.Book;

namespace CleanArchitecture.Domain.Entities
{
    public class Book:Entity<int>
    {
        #region Properites

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public bool IsActive { get; private set; }

        #endregion

        #region Constructors

        public Book()
        {
            Title = string.Empty;
            Description = string.Empty;
            Category = string.Empty;
            IsActive = true;
        }
        private Book(string title, string description, string category, bool isActive)
        {
            Title = title;
            Description = description;
            Category = category;
            IsActive = isActive;
        }
        private Book(int id, string title, string description, string category, bool isActive) : base(id)
        {
            Title = title;
            Description = description;
            Category = category;
            IsActive = isActive;
        }


        #endregion

        #region Factory Method

        public static Book Create(string title, string description, string category, bool isActive)
        {
            var newBook= new Book(title, description, category, isActive);

            //Raise Event For Create Book
            newBook.RegisterNotification(new BookCreatedNotification(newBook));

            return newBook;
        }

        public static Book Create(int id, string title, string description, string category, bool isActive)
        {
            var newBook = new Book(id, title, description, category, isActive);

            //Raise Event For Create Book
            newBook.RegisterNotification(new BookCreatedNotification(newBook));

            return newBook;
        }

        #endregion

        #region Methods

        public Result ChangeTitle(string title)
        {
            //validate
            if (string.IsNullOrEmpty(title))
            {
                return Result.Failure(BookErrors.EmptyTitle);
            }

            Title = title;

            return Result.Success();
        }

        public Result ChangeDescription(string description)
        {
            //validate

            if (string.IsNullOrEmpty(description))
            {
                return Result.Failure(BookErrors.EmptyDescription);
            }

            Description = description;

            return Result.Success();
        }

        public Result ChangeCategory(string category)
        {
            //validate

            if (string.IsNullOrEmpty(category))
            {
                return Result.Failure(BookErrors.EmptyCategory);
            }

            Category = category;

            return Result.Success();
        }

        public void EnableBook()
        {
            IsActive = true;
        }
        public void DisableBook()
        {
            IsActive = false;
        }

        public void Update(string title,string description,string category,bool isActive,int updatedById)
        {
            Title=title;
            Description=description;
            Category=category;
            IsActive = isActive;

            UpdatedDate = DateTime.Now;
            UpdatedBy = updatedById;
        }

        #endregion

    }
}
