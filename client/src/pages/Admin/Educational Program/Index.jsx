import React, { useEffect } from "react";
import { Route, Switch, useRouteMatch, Redirect } from "react-router-dom";
import CreateEduProgram from "./Create";
import EduProgramList from "./List";
import DetailList from './DetailList'
import { Radio } from 'antd'
import { useHistory } from 'react-router-dom'
import AddCourse from "./AddCourse";
export default function ClassManagement({setLoading}) {
    let { path, url } = useRouteMatch();
    const navigate = useHistory()
    const handleFnSelect = (e) => {
        navigate.push(`${path}/${e.target.value}`);
    } 

    let defaultRdGrValue = document.location.pathname.includes("list") ? "list" : "create"  ; 

    return (
        <div id="educational-program-management">
            <h3 className="title">Quản lý chương trình học</h3>
            <Radio.Group defaultValue={defaultRdGrValue} buttonStyle="solid" onChange={handleFnSelect}>
                <Radio.Button value="create">Tạo chương trình học</Radio.Button>
                <Radio.Button value="list">Danh sách chương trình học</Radio.Button>
            </Radio.Group>
            <div className="fns pt-5">
                <Switch>
                    <Route path={`${path}/create`}>
                        <CreateEduProgram setLoading={setLoading}/>
                    </Route>
                    <Route path={`${path}/list/program/:id`}>
                        <DetailList setLoading={setLoading} />
                    </Route>
                    <Route path={`${path}/list/add/:id`}>
                        <AddCourse setLoading={setLoading} />
                    </Route>
                    <Route path={`${path}/list`}>
                        <EduProgramList setLoading={setLoading} />
                    </Route>
                    <Redirect to={`${path}/create`} />
                </Switch>
            </div>
            
        </div>
    )
}