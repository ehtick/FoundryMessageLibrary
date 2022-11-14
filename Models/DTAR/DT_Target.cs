using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Models;

namespace IoBTMessage.Models
{

	public class DT_Target : DT_Searchable
	{
		public DT_Part part;
		public List<DT_Document> models;
		public List<DT_Document> images;
		public List<DT_Component> components;
		public List<DT_Hero> procedures;

		public DT_Target()
		{
			part = new DT_Part();
		}
		public DT_Part CopyFrom(DT_Part source)
		{
			source.CopyNonNullProperties(this.part);
			this.title = ComputeTitle(this.part);
			return this.part;
		}

		public static string ComputeTitle(DT_Part source)
		{
			var title = source.partName();

			if (!string.IsNullOrEmpty(source.serialNumber))
				title = $"{title}:{source.serialNumber}";

			if (!string.IsNullOrEmpty(source.referenceDesignation))
				title = $"{title}@{source.referenceDesignation}";

			return title;
		}

		public List<DT_Document> AddImage(DT_Document image)
		{
			images ??= new List<DT_Document>();
			if (image != null)
				images.Add(image);

			return images;
		}

		public List<DT_Document> AddModel(DT_Document model)
		{
			models ??= new List<DT_Document>();
			if (model != null)
				models.Add(model);

			return models;
		}

		public List<DT_Document> CollectDocumentsFrom(DT_Hero source)
		{
			var documents = source.CollectDocuments(new List<DT_Document>()).Where(obj => obj != null).ToList();
			documents = documents.DistinctUsing(item => item.filename).ToList();

			images ??= new List<DT_Document>();
			models ??= new List<DT_Document>();

			var justImages = documents.Where(item => item.IsImage()).ToList();
			images.AddRange(justImages);


			var justModels = documents.Where(item => item.IsModel()).ToList();
			models.AddRange(justModels);

			return documents;
		}

		public void RemoveDuplicates()
		{
			images ??= new List<DT_Document>();
			images = images.DistinctUsing(item => item.filename).ToList();

			models ??= new List<DT_Document>();
			models = models.DistinctUsing(item => item.filename).ToList();
		}
	}
}