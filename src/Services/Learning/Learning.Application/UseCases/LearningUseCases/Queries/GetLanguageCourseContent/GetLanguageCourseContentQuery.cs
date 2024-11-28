using MediatR;

namespace Learning.Application.UseCases.LearningUseCases.Queries.GetLanguageCourseContent
{
    public record GetLanguageCourseContentQuery() : IRequest<GetLanguageCourseContentResponse>;
    public record GetLanguageCourseContentResponse(Dictionary<int, Dictionary<int, List<int>>> CourseContent);

}
