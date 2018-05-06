﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using StartUpTemplate;

namespace RingsStartUp
{
    public partial class RainbowRingForm : Form
    {
        public StartUpTemplateClass ParentStartUp = null;

        public RainbowRingForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler((Leon, Mathilda) => { ParentStartUp?.OnStartUpFinished(EventArgs.Empty); });
        }

        private void RainbowRingForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            ThreadPool.QueueUserWorkItem(new WaitCallback(
                (Leon) => {
                    int Progress = 0;
                    try
                    {
                        while (Progress < 100)
                        {
                            Thread.Sleep(200);
                            Progress += 5;

                            this.Invoke(new Action(() => {
                                ProgressLabel.Text = string.Format("Hack System Loading ... {0}%", Progress);
                                Application.DoEvents();
                            }));
                        }

                        this.Invoke(new Action(() => {
                            ProgressLabel.Text = "Hack System Loaded !\n Welcome. (〃'▽'〃)";
                            Application.DoEvents();
                        }));

                        if (this == null) return;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(
                            (Mathilda) => {
                                while (this.Opacity > 0)
                                {
                                    Thread.Sleep(100);
                                    this.Opacity -= 0.1;
                                }

                                this.Close();
                            }));
                    }
                    catch { }
                }));
        }
    }
}