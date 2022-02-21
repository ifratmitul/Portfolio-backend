import { Skill } from "./skill";

export interface Project {
  id: string;
  title: string;
  details: string;
  skills: Skill[];
  photos: Photo[];
}

export interface Photo {
  id: string;
  url: string;
  isMain: boolean;
}
