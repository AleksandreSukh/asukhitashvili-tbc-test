using Microsoft.AspNetCore.Mvc;
using Test.API.Filters;

namespace Test.API.Controllers
{
    [ApiController]
    [Route("persons")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(ILogger<PersonsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        [RequestValidationFilter]
        public GetPersonModel Get()
        {
            //ფიზიკური პირის შესახებ სრული ინფორმაციის მიღება იდენტიფიკატორის მეშვეობით
            //(დაკავშირებული ფიზიკური პირების და სურათის ჩათვლით)
            throw new NotImplementedException();
        }       
        
        [HttpGet(Name = "Search")]
        [RequestValidationFilter]
        public List<SearchPersonsModel> Search()
        {
            //ფიზიკური პირების სიის მიღება, სწრაფი ძებნის
            //(სახელი, გვარი, პირადი ნომრის მიხედვით (დამთხვევა sql like პრინციპით)),
            //დეტალური ძებნის (ყველა ველის მიხედვით) და paging-ის ფუნქციით
            throw new NotImplementedException();
        }       
        
        [HttpGet(Name = "ConnectedPersonsReport")]
        [RequestValidationFilter]
        public List<SearchPersonsModel> ConnectedPersonsReport()
        {
            //რეპორტი თუ რამდენი დაკავშირებული პირი ჰყავს თითოეულ ფიზიკურ პირს, კავშირის ტიპის მიხედვით
            throw new NotImplementedException();
        }

        [HttpPost(Name = "Create")]
        [RequestValidationFilter]
        public void Create([FromBody] CreatePersonModel model)
        {
            throw new NotImplementedException();
        }
        
        [HttpPut(Name = "Update")]
        [RequestValidationFilter]
        public void Update([FromBody] UpdatePersonModel model)
        {
            //TODO: ფიზიკური პირის ძირითადი ინფორმაციის ცვლილება, რომელიც მოიცავს შემდეგ მონაცემებს:
            //სახელი, გვარი, სქესი, პირადი ნომერი, დაბადების თარიღი, ქალაქი, ტელეფონის ნომრები
            throw new NotImplementedException();
        }

        [HttpPost(Name = "UploadPicture")]
        [RequestValidationFilter]
        public void UploadPicture()
        {
            //ფიზიკური პირის სურათის ატვირთვა/ცვლილება (სურათი შევინახოთ ფაილურ სისტემაში)
            throw new NotImplementedException();
        }       
        
        [HttpPut(Name = "AddConnectedPerson")]
        [RequestValidationFilter]
        public void AddConnectedPerson()
        {
            throw new NotImplementedException();
        }       
        
        [HttpPut(Name = "RemoveConnectedPerson")]
        [RequestValidationFilter]
        public void RemoveConnectedPerson()
        {
            throw new NotImplementedException();
        }
    }

    //TODO:
    //მონაცემები უნდა შევინახოთ მონაცემთა ბაზაში
    //    • API-ის ყველა ოპერაციის შესრულების დროს უნდა მოხდეს შესაბამისი მონაცემების სტრუქტურის და მთლიანობის ვალიდაცია.შეცდომის შემთხვევაში შესაბამისი მესიჯის დაბრუნება.მესიჯები უნდა იყოს მარტივად ლოკალიზებადი.
    //    • შევქმნათ საერთო Action Filter რომელიც გადაამოწმებს მოთხოვნის მონაცემებს და თუ არ არის ვალიდური დააბრუნებს შესაბამის შეცდომას
    //    • API middleware-ის შექმნა დაუმუშავებელი შეცდომების ლოგირებისთვის
    //    • API middleware-ის შექმნა მოთხოვნის Accept-Language HTTP header პარამეტრის შესაბამისი ლოკალიზაციის/ენის დაყენებისთვის
    //    • სასურველია Repository და Unit of work პატერნების გამოყენება

    public class SearchPersonsModel
    {
    }

    public class UpdatePersonModel
    {
    }

    public class CreatePersonModel
    {
    }

    public class GetPersonModel
    {
    }
}
