import { UserTypeAction } from "./UserRecordTypeAction";

export interface UserAction {
    type: UserTypeAction;
    payload: any;
}