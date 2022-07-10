export interface DT_Base {
	guid: string;
	key: string;
	name: string;
	type: string;
	timeStamp: string;
	version: string;
}

export interface DT_Error extends DT_Base {
	error: string;
	source: any;
}

export interface DT_Hero extends DT_Base {
	title: string;
	description: string;
	parentKey: string;
	heroImage: DT_Document;
}