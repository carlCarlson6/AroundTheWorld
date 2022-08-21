import React from 'react';
import { IUserContext } from './models/IUserContext';

export const UserContext = React.createContext<IUserContext>({} as IUserContext);
