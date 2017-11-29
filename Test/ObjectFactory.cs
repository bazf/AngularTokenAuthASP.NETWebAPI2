namespace Test
{
    using DAL.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjectFactory
    {
        public List<UserNoteEntity> GetUserNoteList()
        {
            return new List<UserNoteEntity>
            {
                new UserNoteEntity
                {
                    Id = 1,
                    Text = "Text1",
                    Title = "Title1",
                    UserId = "id1",
                    UserEntity = new UserEntity
                    {
                        Id = "id1",
                    }
                },
                new UserNoteEntity
                {
                    Id = 2,
                    Text = "Text2",
                    Title = "Title2",
                    UserEntity = new UserEntity
                    {
                        Id = "id2",
                    }
                },
                new UserNoteEntity
                {
                    Id = 3,
                    Text = "Text3",
                    Title = "Title3",
                    UserEntity = new UserEntity
                    {
                        Id = "id3",
                    }
                },
                new UserNoteEntity
                {
                    Id = 4,
                    Text = "Text4",
                    Title = "Title4",
                    UserEntity = new UserEntity
                    {
                        Id = "id4",
                    }
                },
                new UserNoteEntity
                {
                    Id = 5,
                    Text = "Text5",
                    Title = "Title5",
                    UserEntity = new UserEntity
                    {
                        Id = "id5",
                    }
                }
            };
        }

        public List<UserEntity> GetUserList()
        {
            return new List<UserEntity>
            {
                new UserEntity
                {
                    Id = "id1",
                    UserName = "user1",
                    Notes = GetUserNoteList().Where(n => n.UserId == "id1").ToList()
                }
            };
        }
    }
}
