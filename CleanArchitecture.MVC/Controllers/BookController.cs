using AutoMapper;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksService _booksService;
        private readonly IMapper _mapper;

        public BookController(IBooksService booksService,IMapper mapper)
        {
            _booksService = booksService;
            _mapper = mapper;
        }

        #region Get List

        // GET: BooksController
        public async Task<ActionResult> Index()
        {
            //get books list
            var response = await _booksService.GetBooks();

            return View(response.Data);
        }


        #endregion

        #region Get Item

        // GET: BooksController/Details/5
        public async Task<ActionResult> Details(int id)
        { 
            //get book info
            var response = await _booksService.GetBook(id);

            return View(response.Data);
        }

        #endregion

        #region Create

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookViewModel bookViewModel)
        {
            try
            {
                //create book 
                var response = await _booksService.CreateBook(bookViewModel);

                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in response.ValidationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
            }

            return View(bookViewModel);
        }

        #endregion

        #region Update

        // GET: BooksController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //get book info
            var response = await _booksService.GetBook(id);

            //Map BookViewModel To UpdateBookViewModel
            var model = _mapper.Map<UpdateBookViewModel>(response.Data);

            return View(model);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateBookViewModel bookViewModel)
        {
            try
            {
                //update book 
                var response = await _booksService.UpdateBook(bookViewModel);

                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in response.ValidationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(bookViewModel);
        }

        #endregion

        #region Delete

        // GET: BooksController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //get book info
            var response = await _booksService.GetBook(id);

            //Map BookViewModel To DeleteBookViewModel
            var model = _mapper.Map<DeleteBookViewModel>(response.Data);

            return View(model);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,DeleteBookViewModel book)
        {
            try
            {
                book.Id = id;

                //delete book 
                var response = await _booksService.DeleteBook(book.Id);

                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in response.ValidationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(book);
        }

        #endregion

    }
}
