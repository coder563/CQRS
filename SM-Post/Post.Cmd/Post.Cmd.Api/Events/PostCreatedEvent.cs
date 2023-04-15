


using CQRS.Core.Events;

namespace Post.Cmd.Api.Events  {

    public class PostCreatedEvent:BaseEvent{

            protected PostCreatedEvent():base(nameof(PostCreatedEvent)){


                
            }



    }







 }