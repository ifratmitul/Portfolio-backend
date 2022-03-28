import React from 'react'
import AdminLayout from '../../components/layout/AdminLayout';
import { Education } from '../../Model/education';
import { Experience } from '../../Model/Experience';
import { Project } from '../../Model/project';
import { Skill } from '../../Model/skill';

interface Props {
  skills: Skill[];
  projects: Project[];
  experience: Experience[];
  education : Education []
}

const AdminControlPanel = () => {
  return (
    <div>Admin.control-panel</div>
  )
}
AdminControlPanel.layout = AdminLayout;
export default AdminControlPanel