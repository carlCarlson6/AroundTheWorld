import React from "react";
import { IRecordContext } from "./models/IRecordContext";

export const RecordContext = React.createContext<IRecordContext>({} as IRecordContext);
