import React from "react"
import { UserContext } from "../UserContext";
import { userReducer } from "../UserReducer"
import { UserService } from "../UserService"
import { initialUserState } from "./InitialUserState";

export const UserState = (props: any) => {
    const [state, dispatch] = React.useReducer(userReducer, initialUserState);
    const service: UserService = new UserService(dispatch);

    return (
        <UserContext.Provider
            value = {{
                state,
                service
            }}
        >
            {props.children}
        </UserContext.Provider>
    );
}