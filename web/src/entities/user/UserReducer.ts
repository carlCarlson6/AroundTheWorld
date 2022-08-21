import { UserAction } from "./models/action/UserAction";
import { IUserState } from "./state/IUserState";

export const userReducer = (state: IUserState, action: UserAction) => {
    switch (action.type) {

        default:
            return state
    }

}
