import React from 'react';
import { RecordContext } from '../RecordContext';
import { recordReducer } from '../RecordReducer';
import { RecordService } from '../RecordService';
import { initialRecordState } from './InitialRecordState';

export const RecordState = (props: any) => {
    const [state, dispatch] = React.useReducer(recordReducer, initialRecordState);
    const service: RecordService = new RecordService(dispatch);

    return (
        <RecordContext.Provider
            value = {{
                state,
                service
            }}
        >
            {props.children}
        </RecordContext.Provider>
    );
}
