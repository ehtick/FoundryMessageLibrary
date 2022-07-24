export interface DT_StepDetail extends DT_Hero {
	itemNumber: number;
	check: DT_QualityAssurance;
}

export interface DT_Note extends DT_StepDetail {

}

export interface DT_Caution extends DT_StepDetail {

}

export interface DT_Warning extends DT_StepDetail {

}

export interface DT_StepAction extends DT_StepDetail {

}

export interface DT_CAD extends DT_StepDetail {

}

export interface DT_Media extends DT_StepDetail {

}