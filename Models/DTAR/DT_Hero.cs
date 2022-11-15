using System.Collections.Generic;

namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_Hero : DT_Title
	{

		public DT_Document heroImage;
		public List<DT_AssetReference> assetReferences;
		public List<DT_ComponentReference> componentReferences;


#if !UNITY
		public DT_Hero() : base()
		{
		}



		public T AddAssetReference<T>(T item) where T : DT_AssetReference
		{
			if (assetReferences == null)
			{
				assetReferences = new List<DT_AssetReference>();
			}
			assetReferences.Add(item);
			return item;
		}

		public T AddComponentReference<T>(T item) where T : DT_ComponentReference
		{
			if ( componentReferences == null)
			{
				componentReferences = new List<DT_ComponentReference>();
			}
			componentReferences.Add(item);
			return item;
		}

		public virtual List<DT_Document> CollectDocuments(List<DT_Document> list)
		{
			list.Add(heroImage);

			assetReferences?.ForEach(assetRef =>
			{
				list.Add(assetRef?.document);
			});
			return list;
		}

		public virtual List<DT_AssetReference> CollectAssetReferences(List<DT_AssetReference> list)
		{

			if ( assetReferences != null )
				list.AddRange(assetReferences);

			return list;
		}

		public virtual List<DT_ComponentReference> CollectComponentReferences(List<DT_ComponentReference> list)
		{

			componentReferences?.ForEach(compRef =>
			{
				list.Add(compRef);
			});
			return list;
		}

#endif
	}
}
