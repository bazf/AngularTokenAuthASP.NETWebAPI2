namespace Test
{
    using DAL.Entities;
    using System.Collections.Generic;

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
                        Id = "id1",
                    }
                }
            };
        }
    }
}
