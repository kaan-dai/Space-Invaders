//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class DLinkMan : ListBase
    {
        public DLinkMan()
            : base()
        {
            this.poIterator = new DLinkIterator();
            Debug.Assert(this.poIterator != null);

            this.poHead = null;
        }

        override public void AddToFront(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);

            DLink pNode = (DLink)_pNode;
            // add node
            if (poHead == null)
            {
                // push to the front
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // push to front
                pNode.pPrev = null;
                pNode.pNext = poHead;

                // update head
                poHead.pPrev = pNode;
                poHead = pNode;
            }

            // worst case, pHead was null initially,
            // now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        public void AddToEnd(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);
            DLink pNode = (DLink)_pNode;

            // add node
            if (poHead == null)
            {
                // none on list... so add it
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // spin until end
                DLink pTmp = poHead;
                DLink pLast = pTmp;
                while (pTmp != null)
                {
                    pLast = pTmp;
                    pTmp = pTmp.pNext;
                }

                // push to front
                pLast.pNext = pNode;
                pNode.pPrev = pLast;
                pNode.pNext = null;

            }

            // worst case, pHead was null initially,
            // now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        override public void Remove(NodeBase _pNode)
        {
            // There should always be something on list
            Debug.Assert(this.poHead != null);
            Debug.Assert(_pNode != null);

            DLink pNode = (DLink)_pNode;

            // four cases
            if (pNode.pPrev == null && pNode.pNext == null)
            {   // Only node
                poHead = null;
            }
            else if (pNode.pPrev == null && pNode.pNext != null)
            {   // First node
                poHead = pNode.pNext;
                pNode.pNext.pPrev = pNode.pPrev;
            }
            else if (pNode.pPrev != null && pNode.pNext == null)
            {   // Last node
                pNode.pPrev.pNext = pNode.pNext;
            }
            else
            {   // Middle node
                pNode.pNext.pPrev = pNode.pPrev;
                pNode.pPrev.pNext = pNode.pNext;
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Detach();
        }
        override public NodeBase RemoveFromFront()
        {
            // There should always be something on list
            Debug.Assert(poHead != null);

            // return node
            DLink pNode = poHead;

            // Update head (OK if it points to NULL)
            poHead = poHead.pNext;
            if (poHead != null)
            {
                poHead.pPrev = null;
                // do not change pEnd
            }
            else
            {
                // only one on the list
                
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Detach();

            return pNode;
        }

        override public Iterator GetIterator()
        {
            Debug.Assert(this.poIterator != null);
            this.poIterator.Reset(this.poHead);

            return this.poIterator;
        }

        override public void InsertWithPriority(NodeBase _pNode, int priority)
        {

            DLink pNode = (DLink)_pNode;
            pNode.setPriority(priority);

            if (poHead == null)
            {
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                DLink pTmp = poHead;
                DLink pLast = pTmp;
                while (pTmp != null && pTmp.getPriority() <= priority)
                {
                    pLast = pTmp;
                    pTmp = pTmp.pNext;
                }

                if (pTmp == null)
                {
                    pLast.pNext = pNode;
                    pNode.pPrev = pLast;
                    pNode.pNext = null;
                }
                else if (pTmp == poHead)
                {
                    pNode.pNext = poHead;
                    poHead.pPrev = pNode;
                    poHead = pNode;
                }
                else
                {
                    pNode.pNext = pTmp;
                    pNode.pPrev = pTmp.pPrev;
                    pTmp.pPrev.pNext = pNode;
                    pTmp.pPrev = pNode;
                }
            }
            Debug.Assert(poHead != null);
        }
        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public DLink poHead;
        public DLinkIterator poIterator;
    }
}

// --- End of File ---
