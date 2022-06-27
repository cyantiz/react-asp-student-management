import React, { useEffect } from "react";
import { Route, Switch, useRouteMatch, Redirect } from "react-router-dom";
import Create from "./Create";
import List from "./List";
import { Radio } from 'antd'
import { useHistory } from 'react-router-dom'
export default function ClassManagement({setLoading}) {
    let { path, url } = useRouteMatch();
    const navigate = useHistory()
    const handleFnSelect = (e) => {
        navigate.push(`${path}/${e.target.value}`);
    } 

    let defaultRdGrValue = document.location.pathname.includes("list") ? "list" : "create"  ; 

    return (
        <div id="course-management">
            <h3 className="title">Quản lý học phần</h3>
            <Radio.Group defaultValue={defaultRdGrValue} buttonStyle="solid" onChange={handleFnSelect}>
                <Radio.Button value="create">Tạo học phần</Radio.Button>
                <Radio.Button value="list">Danh sách học phần</Radio.Button>
            </Radio.Group>
            <div className="fns pt-5">
                <Switch>
                    <Route path={`${path}/create`}>
                        <Create setLoading={setLoading}/>
                    </Route>
                    <Route path={`${path}/list`}>
                        <List setLoading={setLoading}/>
                    </Route>
                    <Redirect to={`${path}/create`} />
                </Switch>
            </div>
            
        </div>
    )
}
