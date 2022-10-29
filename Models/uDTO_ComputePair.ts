export interface UDTO_ComputePair extends UDTO_Base {
	type: string;
	name: string;
	active: string;
	version: string;
	info: string;
	container: string;
	sourceURL: string;
	targetURL: string;
	lastEvent: string;
	lastError: string;
	purpose: string;
}