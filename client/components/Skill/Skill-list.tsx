import React from 'react';
import { Skill } from '../../Model/skill';
import SkillItem from './Skill-item';
import style from './skill.module.scss';
interface Props {
    skills: Skill[]
}

const SkillList = ({skills}:Props) => {
  return (
    <div className={style['skill__list']}>
        <ul>
            {skills.map((item: Skill) => (
              <SkillItem key={item.id} skill={item} />
            ))}
          </ul>
    </div>
  )
}

export default SkillList