import { Record } from "../models/Record";

export interface IRecordState {
    records: Array<Record>;
    record: Record;
    fetchingData: boolean;
}
