

using CQRS.Core.Domain;
using Post.Common.Events;

namespace Post.Cmd.Domain{

        public class PostAggregate:AggregateRoot{


            private bool _active;
            private string _author;

            private readonly Dictionary<Guid, Tuple<string,string>> _comments = new();


            public bool Active {

                get =>_active  ; set =>_active=value;
            }

            public PostAggregate(Guid id, string author, string message){

                RaiseEvent(new PostCreatedEvent{

                    Id = id,
                    Author = author,
                    Message = message,
                    DatePosted = DateTime.Now
                                        
                });
            }
            
            public void Apply(PostCreatedEvent @event){

                    _id = @event.Id;
                    _active = true;
                    _author = @event.Author;
            }

            public void EditMessage(string message){

                    if(_active==false){

                            throw new InvalidOperationException("You cannot edit message of an inactive post");
                    }else if (string.IsNullOrWhiteSpace(message)){

                            throw new InvalidOperationException($"The value of {nameof(message)} is either blank or null");
                    }

                    RaiseEvent(new MessageUpdatedEvent{

                        Id = _id,
                        Message = message
                    });
                        
            }

            public void Apply(MessageUpdatedEvent @event){

                                _id = @event.Id;                        

            }

            public void LikePost(){


                if(_active==false){

                            throw new InvalidOperationException("You cannot like and inactive post");
                }

                RaiseEvent(new PostLikeEvent{

                        Id = _id
                });


                }


        
             public void Apply(PostLikeEvent @event){
                        _id = @event.Id;
             }

        }




}

                        


