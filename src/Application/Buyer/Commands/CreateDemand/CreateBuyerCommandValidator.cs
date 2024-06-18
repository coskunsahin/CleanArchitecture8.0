using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Buyer.Commands.CreateBuyer;
using FluentValidation;

namespace CleanArchitecture.Application.Buyer.Commands.CreateBuyer;



public class CreateBuyerCommandValidator : AbstractValidator<CreateBuyerCommand>
{
    public CreateBuyerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(x => x.Amount).InclusiveBetween(500, 99999);
        //    RuleFor(x => x.Date)
        //.InclusiveBetween(new DateTime(2008, 01, 01), new DateTime(2100, 01, 01)).WithMessage("Wrong");

        RuleFor(x => x.Date).
Must(DayValidate).WithMessage("Invalid day must be 1 or greater than 28");
    }

   

    protected bool DayValidate(DateTime value)

    {

        DateTime now = DateTime.Today;

        int days = now.Day - Convert.ToDateTime(value).Day;



        if (days<29)

        {

            return true;

        }

        else

        {

            return false;

        }

    }

}
