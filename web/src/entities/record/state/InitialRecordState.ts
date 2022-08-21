import { IRecordState } from "./IRecordState";
import { Record } from "../models/Record";

export const initialRecordState: IRecordState = {
    record: {} as Record,
    records: [],
    fetchingData: false
}
