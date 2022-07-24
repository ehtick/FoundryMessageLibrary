export interface DT_Base {
	guid: string;
	parentGuid: string;
	name: string;
	type: string;
	timeStamp: string;
}

export interface DT_Error extends DT_Base {
	error: string;
	source: any;
}

export interface DT_QualityAssurance extends DT_Base {
	comment: string;
	action: string;
	author: string;
	componentGuid: string;
}

export interface DT_Comment extends DT_Base {
	comment: string;
	severity: string;
	author: string;
}

export interface DT_Title extends DT_Base {
	title: string;
	description: string;
	comments: DT_Comment[];
}

export interface DT_Hero extends DT_Title {
	heroImage: DT_Document;
	primaryAsset: DT_AssetReference;
	assetReferences: DT_AssetReference[];
}