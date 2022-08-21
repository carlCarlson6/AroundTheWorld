import { RecordService } from "../RecordService";
import { IRecordState } from "../state/IRecordState";

export interface IRecordContext {
    state: IRecordState;
    service: RecordService;
}