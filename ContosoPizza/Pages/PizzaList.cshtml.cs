using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        // This variable will hold a reference to a PizzaService object
        private readonly PizzaService _service;

        /** 
            hold the list of pizzas 
            default! - initialized later, so null safety checks aren't required
        */
        public IList<Pizza> PizzaList { get; set;} = default!;
        
        /** 
            BindProperty attribute is used to bind the NewPizza property to the Razor page
            When an HTTP POST request is made, the NewPizza property will be populated with the user's input
        */
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;
        /**
            PizzaListModel class handled the HTTP GET request by setting the value of the PizzaList property to the value of _service.GetPizzas()
        */
        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        //Page Handler for page initialization
        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        // Page handler for HTTP POST
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _service.AddPizza(NewPizza);

            // used to redirect the user to the Get page handler, which will re-render the page with the updated list of pizzas
            return RedirectToAction("Get");
        }
    }
}
