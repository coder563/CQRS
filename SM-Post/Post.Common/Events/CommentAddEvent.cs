

using CQRS.Core.Events;

namespace Post.Common.Events{



    public class CommentAddEvent:BaseEvent{


    public CommentAddEvent():base(nameof(CommentAddEvent)){
    }


    public Guid CommentId{get;set;}

    public string Comment{get;set;}

    public string Username{get;set;}

    public DateTime CommentDate{get;set;}







    }






}