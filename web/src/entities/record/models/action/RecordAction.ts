import { RecordTypeAction } from "./RecordTypeAction";

export interface RecordAction  {
    type: RecordTypeAction;
    payload: any;
}
