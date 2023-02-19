using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;


namespace IoBTMessage.Models
{

	public class DO_Target : DO_Searchable
	{
		public DO_Part part { get; set; }
		public List<DO_AssetFile> models { get; set; }
		public List<DO_AssetFile> images { get; set; }
		public List<DO_Component> components { get; set; }
		public List<DO_Hero> procedures { get; set; }
	}

	public class DT_Target : DT_Searchable
	{
		public DT_Part part;
		public List<DT_AssetFile> models;
		public List<DT_AssetFile> images;
		public List<DT_Component> components;
		public List<DT_Hero> procedures;

		public DT_Target()
		{
			part = new DT_Part();
		}
		public DT_Part CopyFrom(DT_Part source)
		{
			source.CopyNonNullFields(this.part);
			return this.part;
		}


		public List<DT_AssetFile> AddImage(DT_AssetFile image)
		{
			images ??= new List<DT_AssetFile>();
			if (image != null)
				images.Add(image);

			return images;
		}

		public List<DT_AssetFile> AddModel(DT_AssetFile model)
		{
			models ??= new List<DT_AssetFile>();
			if (model != null)
				models.Add(model);

			return models;
		}

		public List<DT_AssetFile> CollectAssetFilesFrom(DT_Hero source, bool deep)
		{
			var assets = source.CollectAssetFiles(new List<DT_AssetFile>(), deep).Where(obj => obj != null).ToList();
			assets = assets.DistinctUsing(item => item.filename).ToList();

			images ??= new List<DT_AssetFile>();
			models ??= new List<DT_AssetFile>();

			var justImages = assets.Where(item => item.IsImage()).ToList();
			images.AddRange(justImages);


			var justModels = assets.Where(item => item.IsModel()).ToList();
			models.AddRange(justModels);

			return assets;
		}

		public void RemoveDuplicates()
		{
			images ??= new List<DT_AssetFile>();
			images = images.DistinctUsing(item => item.filename).ToList();

			models ??= new List<DT_AssetFile>();
			models = models.DistinctUsing(item => item.filename).ToList();
		}
	}
}