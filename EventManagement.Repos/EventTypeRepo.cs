using EventManagement.Data;
using EventManagement.Entities;
using EventManagement.Shared;


namespace EventManagement.Repos
{
    public class EventTypeRepo(EmDbContext context)
    {
        public Result<List<EventType>> GetAll()
        {
            var result = new Result<List<EventType>>();
            try
            {
                result.Data = context.EventTypes.ToList();
            }
            catch (Exception e)
            {
                result.HasError = true;
                result.Message = e.Message;
            }

            return result;
        }

        public Result<EventType?> GetById(int id)
        {
            var result = new Result<EventType?>();
            try
            {
                result.Data = context.EventTypes.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception e)
            {
                result.HasError = true;
                result.Message = e.Message;
            }

            return result;
        }

        public Result<EventType> Save(EventType model)
        {
            var result = new Result<EventType>();
            try
            {
                if (context.EventTypes.Any(e => e.Title == model.Title && e.Id != model.Id))
                {
                    result.HasError = true;
                    result.Message = "Event type with the same title already exists.";
                    return result;
                }
                var objToSave = context.EventTypes.Find(model.Id);

                if (objToSave == null)
                {
                    objToSave = new EventType();
                    context.EventTypes.Add(objToSave);
                }
                objToSave.Title = model.Title;
                objToSave.Description = model.Description;
                objToSave.IsActive = model.IsActive;

                objToSave.UpdatedAt = DateTime.Now;
                objToSave.UpdatedBy = 1; //TODO: get from session

                context.SaveChanges();
                result.Data = objToSave;
            }
            catch (Exception e)
            {
                result.HasError = true;
                result.Message = e.Message;
            }
            return result;
        }

        public Result<bool> Delete(int id)
        {
            var result = new Result<bool>();
            try
            {
                var objToDelete = context.EventTypes.Find(id);
                if (objToDelete == null)
                {
                    result.HasError = true;
                    result.Message = "Event type not found.";
                    return result;
                }
                context.EventTypes.Remove(objToDelete);
                context.SaveChanges();
                result.Data = true;
            }
            catch (Exception e)
            {
                result.HasError = true;
                result.Message = e.Message;
            }
            return result;
        }
    }
}