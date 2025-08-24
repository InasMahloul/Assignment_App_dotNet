namespace Assignment_App.Application.Validators
{
    using FluentValidation;
    using Assignment_App.Application.Commands;

    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title is required.")
                .MaximumLength(100).WithMessage("The title must not exceed 100 characters.");

            
        }
    }
}
