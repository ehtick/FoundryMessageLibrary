export interface UDTO_Platform extends UDTO_3D {
	position: UDTO_Position;
	boundingBox: BoundingBox;
	bodies: UDTO_Body[];
	labels: UDTO_Label[];
	relationships: UDTO_Relationship[];
}