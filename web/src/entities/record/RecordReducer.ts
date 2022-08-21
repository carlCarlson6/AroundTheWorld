import { RecordAction } from "./models/action/RecordAction";
import { IRecordState } from "./state/IRecordState";

// TODO
export const recordReducer = (state: IRecordState, action: RecordAction): IRecordState => {
    switch(action.type) {
        
        default:
            return state;
    }

}
