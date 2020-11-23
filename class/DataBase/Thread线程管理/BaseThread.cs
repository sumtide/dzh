using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dzh
{
    public class BaseThread
    {
        
        public enum ThreadStatus
        {
            created,
            running,
            stoped,
        };
        private int id;
        private bool isAlive;
        private ThreadStatus status;
        private Thread workingThread;

        public BaseThread()
        {
            workingThread = new Thread(WorkFunction);
            id = -1;
            isAlive = false;
            status = ThreadStatus.created;
        }
        public int Tid
        {
            get { return id; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
        }

        public ThreadStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        private static void WorkFunction(object arg)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("BaseThread::WorkFunction{");
                ((BaseThread)arg).Run();
                System.Diagnostics.Trace.WriteLine("BaseThread::WorkFunction }");
            }
            catch (ThreadAbortException abtex)
            {
                System.Diagnostics.Trace.WriteLine("BaseThread::WorkFunction ThreadAboutException" + abtex.ToString());
                Thread.ResetAbort();
            }
            catch (ThreadInterruptedException intex)
            {
                System.Diagnostics.Trace.WriteLine("BaseThread::WorkFunction ThreadAbortException " + intex.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("BaseThread::WorkFunction Exception " + ex.ToString());
            }
            finally
            {
                ((BaseThread)arg).status = ThreadStatus.stoped;
                ((BaseThread)arg).id = -1;
                ((BaseThread)arg).isAlive = false;
            }
        }
        /// <summary>
        /// 执行的操作
        /// </summary>
        public  virtual void Run() { }

        /// <summary>
        /// 开始当前线程
        /// </summary>
        /// <returns></returns>
        public int Start()
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("DLx Framework BaseThread Start() {");
                workingThread.Start(this);
                id = workingThread.ManagedThreadId;
                isAlive = true;
                status = ThreadStatus.running;
                System.Diagnostics.Trace.WriteLine("DLx Framework BaseThread Start() }");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("DLx Framework BaseThread Start() Get an exception: " + ex.ToString());
                id = -1;
                isAlive = false;
                status = ThreadStatus.stoped;
            }
            return 0;
        }
        /// <summary>
        /// 可设置等待时间后合并当前线程
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Stop(int timeout)
        {
            System.Diagnostics.Trace.WriteLine("DLx Framework BaseThread Stop {");
            try
            {
                if (isAlive)
                {
                    System.Diagnostics.Trace.WriteLine("BaseThread Stop: Thread is alive");
                    isAlive = false;

                    if (timeout > 0)
                    {
                        if (!workingThread.Join(timeout))
                        {
                            System.Diagnostics.Trace.WriteLine("BaseThread Stop: Join failed, m_WorkingThread.Abort {");
                            isAlive = false;
                            workingThread.Abort();
                            System.Diagnostics.Trace.WriteLine("BaseThread Stop: Join failed, m_WorkingThread.Abort }");
                        }
                    }
                    else
                    {
                        if (!workingThread.Join(3000))
                        {
                            System.Diagnostics.Trace.WriteLine("BaseThread Stop: Join Timer default = 3000 failed, m_WorkingThread.Abort {");
                            isAlive = false;
                            workingThread.Abort();
                            System.Diagnostics.Trace.WriteLine("BaseThread Stop: Join Timer default = 3000 failed, m_WorkingThread.Abort }");
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("BaseThread Stop: Thread is NOT alive");

                    if (workingThread != null)
                    {
                        System.Diagnostics.Trace.WriteLine("BaseThread Stop: Thread status is UNUSUAL");
                        if (workingThread.IsAlive)
                        {
                            System.Diagnostics.Trace.WriteLine("BaseThread Stop: Force to ABOTR ");
                            workingThread.Abort();
                        }
                    }
                }
                workingThread = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("BaseThread Stop: " + ex.ToString());
            }

            System.Diagnostics.Trace.WriteLine("DLx Framework BaseThread Stop }");
            return 0;
        }
        
        ~BaseThread()
        {
            if (workingThread != null)
            {
                System.Diagnostics.Trace.WriteLine("~BaseThread: Thread status is UNUSUAL");
                if (workingThread.IsAlive)
                {
                    System.Diagnostics.Trace.WriteLine("~BaseThread: Force to ABOTR ");
                    workingThread.Abort();
                }
                workingThread = null;
            }
        }
    }

}
