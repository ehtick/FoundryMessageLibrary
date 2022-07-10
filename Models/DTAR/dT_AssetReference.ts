export interface DT_AssetReference extends DT_Base {
    assetGUID: string;
    sheetStart: string;
    sheetEnd: string;
    start_time: number;
    end_time: number;
    document: DT_Document;
}