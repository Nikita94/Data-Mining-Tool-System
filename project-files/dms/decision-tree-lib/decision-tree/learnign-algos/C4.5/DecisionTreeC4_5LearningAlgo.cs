﻿using dms.solvers.decision.tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.solvers.decision.tree.algo
{
    public class DecisionTreeC4_5LearningAlgo : DTLearningAlgo
    {
        string usedAlgo;
        string[] TeacherTypesList;

        public DecisionTreeC4_5LearningAlgo()
        {
            TeacherTypesList = new string[1];
            TeacherTypesList[0] = "Деревья решений";
            usedAlgo = TeacherTypesList[0];
        }

        public void setUsedAlgo(string used_algo)
        {
            usedAlgo = used_algo;
        }


        public string[] getTeacherTypesList()
        {
            return TeacherTypesList;
        }

        public string[] getTeacherTypesList(ISolver solver)
        {
            return TeacherTypesList;
        }

        public float[] getParams()
        {
            float[] res = new float[1];
            res[0] = 10;
            return res;
        }

        public string[] getParamsNames()
        {
            string[] res = new string[1];
            res[0] = "Максимальная глубина дерева";
            return res;
        }

        public float startLearn(ISolver solver, float[][] train_x, float[] train_y)
        {
            DecisionTree dc_solver = (DecisionTree)solver;
            LearningC4_5(new LearningTable(train_x, train_y), dc_solver.root, (int)solver.GetInputsCount(), (int)solver.GetOutputsCount());
            solver = dc_solver;
            return 0;
        }

        public void LearningC4_5(LearningTable education_table, Node tree_node, int inputs, int outputs)
        {
            LearningClassInfo[] thisClassInfo = education_table.ClassInfoInit(education_table, 0, education_table.LearningClasses.Length);

            int k = 0;
            foreach (LearningClassInfo clinf in thisClassInfo)
            {
                if (clinf.number_of_checked >= 1)
                {
                    k++;
                }
            }

            if (k >= 2)
            {
                LearningTable left_table = new LearningTable();
                LearningTable right_table = new LearningTable();
                tree_node.is_leaf = false;
                int index_of_parametr = 0;
                string best_value_for_split = "";
                TreeBuilder.FindBetterParameter(education_table, ref index_of_parametr, ref best_value_for_split, inputs, outputs);
                tree_node.rule = new Rule();
                tree_node.rule.index_of_param = index_of_parametr;
                tree_node.rule.value = (float)Convert.ToDouble(best_value_for_split);
                tree_node.left_child = new Node();
                tree_node.right_child = new Node();

                left_table.SplitLearningTable(education_table, tree_node.rule, ref left_table, ref right_table);
                LearningC4_5(left_table, tree_node.left_child, inputs, outputs);
                LearningC4_5(right_table, tree_node.right_child, inputs, outputs);


            }
            else
            {
                tree_node.is_leaf = true;
                tree_node.rule = new Rule();
                foreach (LearningClassInfo clinf in thisClassInfo)
                {
                    if (clinf.number_of_checked > 0)
                    {
                        tree_node.rule.value = clinf.class_name;
                    }
                }

            }
        }

        public string getType()
        {
            return "C4.5";
        }
    }
}
