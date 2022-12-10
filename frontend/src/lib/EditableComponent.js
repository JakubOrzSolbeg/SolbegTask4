import React, { useState } from "react";
import ElementMaker from "./ElementMaker";

function EditableComponent(){
    const [fullName, setFullName] = useState("Joe Abraham");
    const [showInputEle, setShowInputEle] = useState(false);

    const [fullName2, setFullName2] = useState("Another name to be used");
    const [showInputEle2, setShowInputEle2] = useState(false);

    const onAnyChange = () => {
        console.log("Full name1: "+ fullName+ " another name: " + fullName2)
    }
    return (
        <div>
                <ElementMaker
                    value={fullName}
                    handleChange={(e) => setFullName(e.target.value)}
                    handleDoubleClick={() => setShowInputEle(true)}
                    handleBlur={() => {
                        setShowInputEle(false);
                        onAnyChange();
                    }
                }
                    showInputEle={showInputEle}
                />
            <ElementMaker
                value={fullName2}
                handleChange={(e) => setFullName2(e.target.value)}
                handleDoubleClick={() => setShowInputEle2(true)}
                handleBlur={() => {
                    setShowInputEle2(false);
                    onAnyChange();
                }
                }
                showInputEle={showInputEle2}
            />
        </div>
    );
}

export default EditableComponent