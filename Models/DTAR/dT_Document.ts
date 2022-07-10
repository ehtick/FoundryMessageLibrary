export interface DT_Document extends DT_Base {
	title: string;
	description: string;
	filename: string;
	url: string;
	docType: string;
}

export interface DT_Image extends DT_Document {

}