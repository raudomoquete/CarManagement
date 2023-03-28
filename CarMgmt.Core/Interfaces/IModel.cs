namespace CarMgmt.Core
{
	public interface IModel
	{
		IEnumerable<Model> GetModels();

		Task<Model> GetModelById(int id);

		Task AddModel(Model model);

		Task<bool> UpdateModel(Model model);

		Task<bool> DeleteModel(int id);
	}
}
